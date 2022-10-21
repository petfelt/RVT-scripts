
declare global.number[0] with network priority low
declare global.number[1] with network priority local
declare global.number[2] with network priority low
declare global.number[3] with network priority local
declare global.number[4] with network priority local
declare global.number[5] with network priority low
declare global.number[6] with network priority low
declare global.number[7] with network priority low
declare global.number[8] with network priority low = script_option[15]
declare global.number[9] with network priority low
declare global.number[10] with network priority low
declare global.number[11] with network priority low
declare global.object[0] with network priority low
declare global.object[1] with network priority local
declare global.object[2] with network priority low
declare global.object[3] with network priority low
declare global.object[4] with network priority low
declare global.object[5] with network priority low
declare global.object[6] with network priority low
declare global.object[7] with network priority low
declare global.player[0] with network priority local
declare global.player[1] with network priority local
declare global.player[2] with network priority local
declare global.team[0] with network priority low
declare global.team[1] with network priority low
declare global.timer[0] = script_option[3]
declare global.timer[1] = 10
declare global.timer[2] = 5
declare player.number[0] with network priority low
declare player.number[1] with network priority low
declare player.number[2] with network priority low = 1
declare player.number[3] with network priority low
declare player.number[4] with network priority low
declare player.number[5] with network priority low
declare player.number[6] with network priority low
declare player.object[0] with network priority local
declare player.object[1] with network priority local
declare player.object[2] with network priority low
declare player.object[3] with network priority low
declare player.timer[0] = script_option[14]
declare player.timer[1] = 5
declare player.timer[2] = 1
declare player.timer[3] = 2
declare object.number[0] with network priority low
declare object.timer[0] = script_option[3]
declare object.timer[1] = script_option[13]
declare object.player[0] with network priority low

function check_distance()
   if global.number[7] == 0 and global.number[6] <= 75 then
      global.number[6] += 1
      global.object[4].attach_to(global.object[5], 0, 0, -2, relative)
      global.object[4].detach()
      global.object[5].attach_to(global.object[4], 0, 0, 0, relative)
      global.object[5].detach()
      for each object with label "BoZ_Floor" do
         if current_object.shape_contains(global.object[4]) then
            global.number[7] = 1
         end
      end
      if global.object[4].is_out_of_bounds() then
         global.object[4].attach_to(global.object[5], 0, 0, 2, relative)
         global.object[4].detach()
         global.number[7] = 1
      end
      check_distance()
   end
   if global.number[6] > 75 then
      global.object[4].attach_to(global.player[0].object[0], 0, 0, -18, relative)
      global.object[5].attach_to(global.player[0].object[0], 0, 0, -18, relative)
      global.object[4].detach()
      global.object[5].detach()
   end
end

for each player do
   if current_player.number[0] != 1 then 
      if current_player.is_elite() then 
         current_player.set_loadout_palette(elite_tier_1)
      end
      if not current_player.is_elite() then 
         current_player.set_loadout_palette(spartan_tier_1)
      end
   end
   if current_player.number[0] == 1 then 
      if current_player.is_elite() then 
         current_player.set_loadout_palette(elite_tier_2)
      end
      if not current_player.is_elite() then 
         current_player.set_loadout_palette(spartan_tier_2)
      end
   end
end

do
   global.number[3] = 0
   global.number[4] = -1
   for each player do
      global.number[4] += 1
      if current_player.number[0] == 1 then 
         global.number[3] += 1
      end
   end
   for each player randomly do
      if global.number[3] < script_option[0] and global.number[3] < global.number[4] and current_player.number[1] != 1 and current_player.number[0] != 1 then 
         current_player.number[0] = 1
         global.number[3] += 1
      end
   end
   for each player do
      if current_player.number[0] == 1 and current_player.team != team[1] then 
         send_incident(inf_new_zombie, current_player, no_player)
         current_player.team = team[1]
         current_player.apply_traits(script_traits[0])
         current_player.biped.kill(true)
      end
   end
end

on local: do
   for each player do
      if current_player.number[0] == 1 then
         current_player.timer[3].set_rate(-100%)
         global.number[5] = 0
         global.object[3] = current_player.biped
         global.object[2] = current_player.biped.place_at_me(hill_marker, none, none, 0, 0, 1, none)
         global.object[2].attach_to(global.object[3], 0, 0, 0, relative)
         global.object[2].detach()
         global.number[5] = current_player.biped.get_distance_to(global.object[2])
         global.object[2].delete()
         if current_player.is_spartan() then 
            if global.number[5] <= 2 and current_player.number[4] == 0 then 
               current_player.number[4] = 1
               current_player.timer[3].reset()
            end
            if global.number[5] >= 3 and current_player.number[4] == 1 then 
               current_player.number[4] = 2
               current_player.timer[3].reset()
            end
            if global.number[5] <= 2 and current_player.number[4] == 2 then 
               current_player.number[4] = 3
               current_player.timer[3].reset()
            end
            if global.number[5] >= 3 and current_player.number[4] == 3 then 
               current_player.number[4] = 4
               current_player.timer[3].reset()
            end
         end
         if current_player.is_elite() then 
            if global.number[5] >= 4 and current_player.number[4] == 3 then 
               current_player.number[4] = 4
               current_player.timer[3].reset()
            end
            if global.number[5] <= 3 and current_player.number[4] == 2 then 
               current_player.number[4] = 3
               current_player.timer[3].reset()
            end
            if global.number[5] >= 4 and current_player.number[4] == 1 then 
               current_player.number[4] = 2
               current_player.timer[3].reset()
            end
            if global.number[5] <= 3 and current_player.number[4] == 0 then 
               current_player.number[4] = 1
               current_player.timer[3].reset()
            end
         end
         if current_player.timer[3].is_zero() then 
            current_player.number[4] = 0
         end
      end
   end
end

for each player do
   script_widget[0].set_text("Safe Haven - %s", global.timer[0])
   script_widget[0].set_visibility(current_player, false)
end

for each player do
   current_player.timer[1].set_rate(-100%)
   for each player do
      if current_player.team == team[0] then 
         current_player.set_round_card_title("Dive away from the zombie bombs!")
      end
   end
   for each player do
      if current_player.team == team[1] then 
         current_player.set_round_card_title("Crouch twice to drop bombs on those\npesky humans!")
      end
   end
end

for each player do
   if current_player.number[3] == 0 and current_player.timer[1].is_zero() then 
      game.show_message_to(current_player, announce_infection, "Bomber Zombies")
      for each object with label "BoZ_Floor" do
         global.object[6] = current_object.place_at_me(flag_stand, none, none, 0, 0, 0, none)
         global.object[6].attach_to(current_object, 0, 0, 0, relative)
         global.object[6].detach()
         current_object.attach_to(global.object[6], 0, 0, 0, relative)
         current_object.set_scale(1)
         current_object.detach()
         global.object[6].delete()
      end
      for each object with label "BoZ_Tele" do
         global.object[6] = current_object.place_at_me(sound_emitter_alarm_2, none, none, 0, 0, 0, none)
         global.object[6].attach_to(current_object, 0, 0, 0, relative)
         global.object[6].detach()
         current_object.attach_to(global.object[6], 0, 0, 0, relative)
         current_object.set_scale(1)
         current_object.detach()
         global.object[6].delete()
      end
      current_player.number[3] = 1
   end
   global.object[3] = no_object
   global.object[3] = current_player.biped
   if global.object[3] != no_object then
      global.object[3].player[0] = current_player
   end
   if global.object[3] != no_object and current_player.number[3] == 1 then 
      if current_player.number[0] == 1 then
         current_player.object[0] = global.object[3].place_at_me(sound_emitter_alarm_2, "BoZ_NO_USE_Zkillcheck", none, 0, 0, 0, none)
         current_player.object[0].set_shape(cylinder, 27, 0, 1000)
      end
      if current_player.number[0] != 1 then
         current_player.object[0] = global.object[3].place_at_me(sound_emitter_alarm_2, none, none, 0, 0, 0, none)
      end
      current_player.object[0].attach_to(global.object[3], 0, 0, -2, relative)
      global.object[6] = current_player.object[0]
      global.object[6].player[0] = current_player
      current_player.object[1] = current_player.object[0].place_at_me(sound_emitter_alarm_2, none, none, 0, 0, 0, none)
      current_player.object[1].attach_to(current_player.object[0], 0, 0, 0, relative)
      current_player.object[2] = current_player.object[1].place_at_me(sound_emitter_alarm_2, none, none, 0, 0, 0, none)
      current_player.object[2].attach_to(current_player.object[0], 0, 0, 0, relative)
      current_player.number[3] = 2
   end
end

for each player do
   current_player.team = team[0]
   if current_player.number[0] == 1 then 
      current_player.team = team[1]
      current_player.apply_traits(script_traits[0])
   end
end

for each player do
   if current_player.killer_type_is(guardians | suicide | kill | betrayal | quit) then 
      current_player.object[0].detach()
      current_player.number[1] = 0
      global.player[0] = current_player
      global.player[1] = no_player
      global.player[1] = current_player.try_get_killer()
      if current_player.killer_type_is(kill) and global.player[0].number[0] == 1 and global.player[0].number[0] != global.player[1].number[0] then 
         global.player[1].score += script_option[7]
         send_incident(zombie_kill_kill, global.player[1], global.player[0])
      end
      if current_player.killer_type_is(kill) and script_option[2] == 1 and global.player[0].number[0] == 1 and global.player[0].number[0] != global.player[1].number[0] and global.player[1].number[2] == 1 then 
         global.player[1].score += script_option[6]
      end
      if current_player.killer_type_is(kill) and not global.player[1] == no_player and global.player[0].number[0] == 0 then 
         global.player[0].number[0] = 1
         send_incident(inf_new_infection, global.player[1], global.player[0])
         send_incident(infection_kill, global.player[1], global.player[0])
         global.player[1].score += script_option[10]
         global.player[1].script_stat[1] += 1
         global.player[1].number[5] = 1
      end
      if current_player.killer_type_is(suicide) then
         global.player[1].score += script_option[8]
         current_player.number[0] = 1
      end
      if current_player.killer_type_is(betrayal) and global.player[0].number[0] == global.player[1].number[0] then 
         global.player[1].score += script_option[9]
      end
      if not current_player.killer_type_is(betrayal) and global.player[0].number[0] == 0 then 
         for each object with label "BoZ_NO_USE_Zkillcheck" do
            global.player[2] = current_object.player[0]
            if global.player[2].number[0] == 1 then
               if current_object.shape_contains(current_player.object[0]) and global.player[2] != current_player then
                  global.player[2].score += script_option[12]
                  global.player[2].script_stat[1] += 1
               end
            end
         end
         for each player do
            if current_player.number[0] == 1 then
               send_incident(infection_kill, current_player, global.player[0])
               current_player.score += script_option[10]
            end
         end
         send_incident(inf_new_infection, global.team[1], global.player[0])
         current_player.number[0] = 1
      end
      current_player.object[0].delete()
   end
end

on object death: do
   if killed_object.is_of_type(spartan) or killed_object.is_of_type(elite) or killed_object.is_of_type(monitor) then
      global.player[0] = killed_object.player[0]
      global.player[0].object[0].delete()
      global.player[0].object[1].delete()
      global.player[0].object[2].delete()
      global.player[0].number[3] = 1
   end
end

for each player do
   if current_player.number[4] == 4 and current_player.timer[0].is_zero() and current_player.number[0] == 1 then 
      global.number[6] = 0
      global.number[7] = 0
      global.player[0] = current_player
      global.object[4] = current_player.object[1]
      global.object[5] = current_player.object[2]
      global.object[4].detach()
      global.object[5].detach()
      check_distance()
      global.object[3] = global.object[4].place_at_me(fusion_coil, "BoZ_NO_USE_zombie_bomb", none, -5, -5, 0, none)
      global.object[3].timer[1].reset()
      global.object[3].timer[1].set_rate(-100%)
      global.object[3] = global.object[4].place_at_me(fusion_coil, "BoZ_NO_USE_zombie_bomb", none, -5, 5, 0, none)
      global.object[3].timer[1].reset()
      global.object[3].timer[1].set_rate(-100%)
      global.object[3] = global.object[4].place_at_me(fusion_coil, "BoZ_NO_USE_zombie_bomb", none, 4, 0, 0, none)
      global.object[3].timer[1].reset()
      global.object[3].timer[1].set_rate(-100%)
      current_player.number[4] = 0
      current_player.timer[0].reset()
      current_player.object[1].attach_to(current_player.object[0], 0, 0, 0, relative)
      current_player.object[2].attach_to(current_player.object[0], 0, 0, 0, relative)
   end
end

for each object with label "BoZ_NO_USE_zombie_bomb" do
   if current_object.timer[1].is_zero() then 
      current_object.kill(false)
   end
end

if script_option[2] == 1 and global.object[0] == no_object then 
   global.object[0] = get_random_object("inf_haven", global.object[1])
   if global.number[1] == 1 then 
      send_incident(hill_moved, all_players, all_players)
   end
   global.number[1] = 1
end

if script_option[2] == 1 and global.timer[0].is_zero() then 
   global.timer[0].set_rate(0%)
   global.timer[0] = script_option[3]
   global.object[0].set_waypoint_visibility(no_one)
   global.object[0].set_shape_visibility(no_one)
   global.object[0].set_waypoint_timer(none)
   global.object[0].number[0] = 0
   global.object[1] = global.object[0]
   global.object[0] = no_object
   global.object[0] = get_random_object("inf_haven", global.object[1])
end

do
   global.object[0].set_waypoint_visibility(everyone)
   global.object[0].set_waypoint_icon(crown)
   global.object[0].set_shape_visibility(everyone)
   global.object[0].set_waypoint_priority(high)
end

if script_option[2] == 1 then 
   for each player do
      if global.object[0].shape_contains(current_player.biped) and current_player.number[0] == 0 and global.object[0].number[0] == 0 then 
         global.timer[0].set_rate(-100%)
         global.object[0].number[0] = 1
      end
   end
   if global.object[0].number[0] == 1 then 
      global.object[0].timer[0] = global.timer[0]
      global.object[0].set_waypoint_timer(0)
      if global.object[0].timer[0] < 6 then 
         global.object[0].set_waypoint_priority(blink)
      end
   end
end

if script_option[1] == 1 then 
   global.number[3] = 0
   if global.number[0] == 0 then 
      for each player do
         if not current_player.number[0] == 1 then 
            global.number[3] += 1
         end
      end
      if global.number[3] == 1 then 
         for each player do
            if not current_player.number[0] == 1 and current_player.biped != no_object then 
               current_player.apply_traits(script_traits[1])
               current_player.biped.set_waypoint_icon(skull)
               current_player.biped.set_waypoint_priority(high)
               current_player.biped.remove_weapon(primary, true)
               current_player.biped.add_weapon(plasma_repeater, primary)
               current_player.biped.remove_weapon(secondary, true)
               current_player.biped.add_weapon(concussion_rifle, secondary)
               for each object with label "BoZ_Map_Has_Target_Locator" do
                  current_player.biped.remove_weapon(secondary, true)
                  current_player.biped.add_weapon(target_locator, secondary)
               end
               for each object with label "BoZ_Tele" do
                  if current_object.spawn_sequence == 1 then
                     current_object.set_shape(cylinder, 28, 20, 20)
                     current_object.attach_to(current_player.biped, 0, 0, 0, relative)
                     current_player.object[3] = current_object
                  end
               end
               current_player.number[1] = 1
               current_player.score += script_option[11]
               send_incident(inf_last_man, current_player, all_players)
               game.show_message_to(current_player, none, "Start shooting!")
               global.number[0] = 1
            end
         end
      end
   end
end

for each player do
   if current_player.number[1] == 1 then 
      current_player.apply_traits(script_traits[1])
      if current_player.object[3] == no_object then
         for each object with label "BoZ_Tele" do
            if current_object.spawn_sequence == 1 then
               current_object.detach()
               current_object.set_shape(cylinder, 28, 20, 20)
               current_object.attach_to(current_player.biped, 0, 0, 0, relative)
               current_player.object[3] = current_object
            end
         end
      end
   end
end

for each player do
   script_widget[0].set_visibility(current_player, false)
   if current_player.number[1] != 1 then
      current_player.biped.set_waypoint_icon(none)
   end
   current_player.number[2] = 0
   if script_option[2] == 1 and global.object[0].shape_contains(current_player.biped) and current_player.number[0] == 0 then 
      current_player.number[2] = 1
      current_player.apply_traits(script_traits[2])
      if current_player.number[1] != 1 then
         current_player.biped.set_waypoint_icon(bullseye)
      end
      script_widget[0].set_visibility(current_player, true)
   end
end

do
   global.timer[1].set_rate(-100%)
   if global.timer[1].is_zero() then 
      global.number[3] = 0
      for each player do
         if current_player.number[0] == 0 then 
            global.number[3] += 1
         end
      end
      for each player do
         if global.number[3] == 1 and current_player.number[0] == 0 and current_player.killer_type_is(suicide) then 
            global.number[3] = 0
         end
      end
      if global.number[3] == 0 then 
         send_incident(infection_zombie_win, all_players, all_players)
         for each player do
            if current_player.number[1] != 1 and current_player.number[0] == 1 then 
               current_player.score += script_option[4]
            end
         end
         game.end_round()
      end
   end
end

if game.round_timer.is_zero() and game.round_time_limit > 0 then 
   global.number[3] = 0
   for each player do
      if current_player.number[0] == 0 then 
         global.number[3] += 1
      end
   end
   if not global.number[3] == 0 then 
      send_incident(infection_survivor_win, all_players, all_players)
      for each player do
         if current_player.number[0] == 0 then 
            current_player.score += script_option[5]
         end
      end
      game.end_round()
   end
end

for each player do
   if current_player.number[0] == 0 then 
      current_player.timer[2].set_rate(-100%)
      if current_player.timer[2].is_zero() then 
         current_player.script_stat[0] += 1
         current_player.timer[2].reset()
      end
   end
   current_player.timer[0].set_rate(-100%)
end

if global.number[8] > 0 then
   global.number[9] = game.round_timer
   global.number[9] %= global.number[8]
   if global.number[9] == 0 then
      global.timer[2].reset()
      global.timer[2].set_rate(-100%)
   end
   for each player do
      if current_player.number[1] != 1 then
         if not global.timer[2].is_zero() then
            if current_player.number[0] == 0 then
               current_player.apply_traits(script_traits[3])
               current_player.biped.set_waypoint_icon(bullseye)
               if current_player.number[6] == 0 then
                  game.show_message_to(current_player, timer_beep, "Location revealed")
               end
            end
            if current_player.number[6] == 0 and current_player.number[0] == 1 then
               game.show_message_to(current_player, timer_beep, "Humans revealed")
            end
            current_player.number[6] = 1
         end
         if global.timer[2].is_zero() and current_player.number[6] == 1 then
            if current_player.number[0] == 0 then
               game.show_message_to(current_player, timer_beep, "Location hidden")
               current_player.biped.set_waypoint_icon(none)
            end
            current_player.number[6] = 0
         end
      end
   end
end

if global.number[8] == -1 then
   for each player do 
      if current_player.number[0] == 0 and current_player.number[1] != 1 then
         current_player.apply_traits(script_traits[3])
         current_player.biped.set_waypoint_icon(bullseye)
      end
   end
end