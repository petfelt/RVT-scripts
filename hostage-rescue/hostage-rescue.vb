
declare global.number[0] with network priority local
declare global.number[1] with network priority local
declare global.number[2] with network priority local
declare global.number[3] with network priority local
declare global.number[4] with network priority low
declare global.number[5] with network priority low
declare global.number[6] with network priority low
declare global.number[7] with network priority low
declare global.number[8] with network priority low
declare global.number[9] with network priority low
declare global.number[10] with network priority low
declare global.number[11] with network priority low
declare global.object[0] with network priority local
declare global.object[1] with network priority local
declare global.object[2] with network priority local
declare global.object[3] with network priority low
declare global.player[0] with network priority local
declare global.player[1] with network priority low
declare global.player[2] with network priority low
declare global.team[0] with network priority low
declare global.timer[0] = 6
declare player.number[0] with network priority local
declare player.number[1] with network priority low
declare player.number[2] with network priority low
declare player.object[0] with network priority low
declare player.object[1] with network priority low
declare player.timer[0] = 5
declare object.number[0] with network priority low
declare object.number[1] with network priority low
declare object.number[2] with network priority low
declare object.object[0] with network priority low
declare object.object[1] with network priority low
declare object.object[2] with network priority low

if game.teams_enabled == 1 then 
   for each object with label "ffa_only" do
      current_object.delete()
   end
end

if game.teams_enabled == 0 then 
   for each object with label "team_only" do
      current_object.delete()
   end
end

for each player do
   if current_player.is_elite() then 
      current_player.set_loadout_palette(elite_tier_1)
   end
   if not current_player.is_elite() then 
      current_player.set_loadout_palette(spartan_tier_1)
   end
end

for each player do
   if game.score_to_win != 0 and game.teams_enabled == 1 then 
      current_player.set_round_card_title("Kill players on the enemy team.\r\nDo NOT kill the Hostage.\r\n%n points to win.", game.score_to_win)
   end
   if game.score_to_win != 0 and game.teams_enabled == 0 then 
      current_player.set_round_card_title("Score points by killing other players.\r\nDo NOT kill the Hostage.\r\n%n points to win.", game.score_to_win)
   end
   if game.score_to_win == 0 and game.teams_enabled == 1 then 
      current_player.set_round_card_title("Kill players on the enemy team.\nDo NOT kill the Hostage.")
   end
   if game.score_to_win == 0 and game.teams_enabled == 0 then 
      current_player.set_round_card_title("Score points by killing other players.\r\nDo NOT kill the Hostage.")
   end
end

for each player do
   current_player.timer[0].set_rate(-100%)
   if current_player.number[1] == 0 then 
      script_widget[0].set_visibility(current_player, false)
      script_widget[1].set_visibility(current_player, false)
      script_widget[2].set_visibility(current_player, false)
   end
   if current_player.number[1] == 0 and current_player.timer[0].is_zero() then 
      game.show_message_to(current_player, announce_slayer, "Hostage Rescue")
      current_player.number[1] = 1
      current_player.timer[0].reset()
   end
   if current_player.number[1] == 1 and current_player.timer[0].is_zero() then 
      game.show_message_to(current_player, none, "(v1.00)  -  Created by mini nt")
      current_player.number[1] = 2
   end
end

for each player do
   global.number[1] = 0
   current_player.script_stat[0] = current_player.rating
   current_player.number[0] = 0
   if game.teams_enabled == 1 then 
      global.number[1] = current_player.team.get_scoreboard_pos()
   end
   if game.teams_enabled == 0 then 
      global.number[1] = current_player.get_scoreboard_pos()
   end
   if global.number[1] == 1 and not current_player.score == 0 then 
      current_player.number[0] = 1
   end
end

if script_option[0] == 3 or script_option[0] == 7 then 
   for each object with label 1 do
      current_object.delete()
   end
end

for each player do
   if current_player.number[2] == 1 then 
      global.player[1] = current_player
      current_player.apply_traits(script_traits[1])
      global.object[1] = no_object
      global.object[1] = current_player.try_get_weapon(primary)
      if global.object[1] != no_object then 
         current_player.biped.remove_weapon(primary, false)
         current_player.frag_grenades -= 4
         current_player.plasma_grenades -= 4
      end
      global.object[0] = no_object
      global.object[0] = current_player.try_get_armor_ability()
      if not global.object[0].is_of_type(sprint) and global.object[0] != no_object then 
         global.object[0].delete()
         global.object[3] = current_player.biped.place_at_me(sprint, none, none, 0, 0, 1, none)
         global.object[3].attach_to(current_player.biped, 0, 0, 1, relative)
         global.object[3].detach()
      end
      if global.object[0].is_of_type(sprint) then 
         current_player.apply_traits(script_traits[3])
      end
      script_widget[1].set_text("You are the Hostage")
      script_widget[2].set_text("%n is the Hostage", global.player[1])
      script_widget[1].set_visibility(current_player, true)
      script_widget[2].set_visibility(current_player, false)
   end
   if global.number[4] == 1 and current_player.number[2] == 0 then 
      script_widget[1].set_visibility(current_player, false)
      script_widget[2].set_visibility(current_player, true)
   end
   if global.number[4] == 0 then 
      script_widget[1].set_visibility(current_player, false)
      script_widget[2].set_visibility(current_player, false)
   end
end

for each object with label "Hostage_Select" do
   if current_object.number[0] == 0 then 
      current_object.set_waypoint_icon(vip)
      current_object.set_waypoint_range(0, 100)
      current_object.set_waypoint_text("BE THE HOSTAGE")
      current_object.set_waypoint_visibility(everyone)
      current_object.set_shape_visibility(everyone)
      current_object.number[0] = 1
   end
   if global.number[4] == 1 then 
      current_object.set_waypoint_visibility(no_one)
      current_object.set_shape_visibility(no_one)
   end
   if global.number[4] == 0 then 
      current_object.set_waypoint_visibility(everyone)
      current_object.set_shape_visibility(everyone)
   end
   for each player do
      if current_object.shape_contains(current_player.biped) and global.number[4] == 0 then 
         current_player.number[2] = 1
         global.number[4] = 1
      end
   end
end

for each player do
   if not global.timer[0].is_zero() then 
      script_widget[0].set_visibility(current_player, true)
   end
   if global.timer[0].is_zero() then 
      script_widget[0].set_visibility(current_player, false)
   end
end

for each player do
   global.number[1] = 0
   global.object[0] = current_player.biped
   if global.object[0] != no_object then 
      current_player.object[0] = global.object[0]
   end
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) then 
      current_player.score += script_option[2]
      if current_player.killer_type_is(kill) then 
         global.player[0] = current_player.try_get_killer()
         global.player[0].score += script_option[1]
         if global.player[0] == global.player[1] then 
            global.player[0].score += script_option[13]
         end
         if current_player.number[2] == 1 then 
            global.player[0].score += script_option[12]
            global.player[2] = current_player.try_get_killer()
            script_widget[0].set_text("%n killed the Hostage!", global.player[2])
            global.timer[0].reset()
            global.timer[0].set_rate(-100%)
            current_player.number[2] = 0
            global.number[4] = 0
            global.player[1] = no_player
         end
         do
            global.number[2] = 0
            global.number[3] = 0
            global.number[3] = current_player.try_get_death_damage_type()
            if global.number[3] == 6 then 
               global.number[2] = current_player.object[0].get_distance_to(global.player[0].object[0])
               if global.number[2] > 400 then 
                  send_incident(dlc_achieve_5, global.player[0], current_player)
               end
            end
         end
         global.number[0] = current_player.try_get_death_damage_mod()
         global.number[1] = global.player[0].get_spree_count()
         do
            global.number[1] %= 5
            if global.number[1] == 0 then 
               global.player[0].score += script_option[11]
            end
         end
         if current_player.number[0] == 1 then 
            global.player[0].score += script_option[5]
         end
         if global.number[0] == 1 then 
            global.player[0].score += script_option[7]
         end
         if global.number[0] == 2 then 
            global.player[0].score += script_option[8]
         end
         if global.number[0] == 3 then 
            global.player[0].score += script_option[9]
         end
         if global.number[0] == 4 then 
            global.player[0].score += script_option[10]
         end
         if global.number[0] == 5 then 
            global.player[0].score += script_option[6]
         end
      end
      if current_player.number[2] == 1 then 
         script_widget[1].set_text("")
         script_widget[2].set_text("")
      end
   end
end

for each player do
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) and not current_player.killer_type_is(kill) and not current_player.killer_type_is(betrayal) then 
      current_player.score += script_option[3]
      if current_player.number[2] == 1 then 
         current_player.score += script_option[12]
         script_widget[0].set_text("The Hostage has died.")
         global.timer[0].reset()
         global.timer[0].set_rate(-100%)
         current_player.number[2] = 0
         global.number[4] = 0
         global.player[1] = no_player
      end
   end
end

for each player do
   if current_player.killer_type_is(betrayal) then 
      global.player[0] = current_player.try_get_killer()
      global.player[0].score += script_option[4]
      if current_player.number[2] == 1 then 
         global.player[2] = current_player.try_get_killer()
         global.player[0].score += script_option[12]
         script_widget[0].set_text("%n betrayed the Hostage!", global.player[2])
         global.timer[0].reset()
         global.timer[0].set_rate(-100%)
         current_player.number[2] = 0
         global.number[4] = 0
         global.player[1] = no_player
      end
   end
end

for each player do
   global.object[2] = no_object
   global.object[2] = current_player.try_get_armor_ability()
   if global.object[2].is_of_type(drop_shield) then 
      if not global.object[2].is_in_use() and global.object[2].number[3] < 3 then 
         global.object[2].number[3] += 1
         for each object do
            global.number[7] = current_object.get_distance_to(global.object[2])
            global.number[10] = 0
            global.number[10] = current_object.shields
            if global.number[7] < 6 and not current_object.is_of_type(spartan) and not current_object.is_of_type(elite) and not current_object.is_of_type(monitor) and not current_object.is_of_type(drop_shield) and not current_object.is_of_type(sabre) and global.number[10] > 97 then 
               global.object[3] = current_object.place_at_me(hill_marker, none, none, 0, 0, 1, none)
               global.object[3].attach_to(current_object, 0, 0, 0, relative)
               global.object[3].set_shape(sphere, 12)
               current_object.object[0] = global.object[3]
               current_player.object[1] = global.object[3]
            end
         end
      end
      if global.object[2].is_in_use() then 
         global.object[2].number[3] = 0
      end
   end
end

for each player do
   if current_player.object[1] != no_object then 
      global.object[3] = current_player.object[1]
      for each player do
         if global.object[3].shape_contains(current_player.biped) and current_player.number[2] == 1 then 
            current_player.apply_traits(script_traits[2])
         end
      end
   end
end

for each object with label "Falcon_Plus" do
   if current_object.number[1] == 0 then
      global.object[0] = current_object.place_at_me(mongoose, none, never_garbage_collect, 0, 0, 1, none)
      global.object[0].attach_to(current_object, 0, 7, 1, relative)
      current_object.object[1] = global.object[0]
      global.object[0] = current_object.place_at_me(mongoose, none, never_garbage_collect, 0, 0, 1, none)
      global.object[0].attach_to(current_object, 0, -7, 1, relative)
      current_object.object[2] = global.object[0]
      current_object.number[1] = 1
   end
   if current_object.number[1] == 1 then
      current_object.number[2] = 0
      for each player do
         global.number[3] = current_object.get_distance_to(current_player.biped)
         if global.number[3] < 20 then
            global.object[0] = current_player.get_vehicle()
            if global.object[0] == no_object then
               current_object.number[2] += 1
            end
         end
      end
      if current_object.number[2] > 0 then
         current_object.object[1].detach()
         current_object.object[2].detach()
      end
      global.number[3] = current_object.get_distance_to(current_object.object[1])
      if global.number[3] > 20 then
         current_object.object[1].copy_rotation_from(current_object, true)
         current_object.object[1].attach_to(current_object, 0, 7, 1, relative)
      end
      global.number[3] = current_object.get_distance_to(current_object.object[2])
      if global.number[3] > 20 then
         current_object.object[2].copy_rotation_from(current_object, true)
         current_object.object[2].attach_to(current_object, 0, -7, 1, relative)
      end
   end
end

on object death: do
   current_object.object[0].delete()
   current_object.object[1].delete()
   current_object.object[2].delete()
end

if game.round_time_limit > 0 and game.round_timer.is_zero() then 
   game.end_round()
end

for each player do
   if current_player.number[0] == 1 then 
      current_player.apply_traits(script_traits[0])
   end
end
